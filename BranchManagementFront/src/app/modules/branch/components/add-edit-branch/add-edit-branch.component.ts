import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { BranchService } from '../../services/branch.service'

@Component({
  selector: 'app-add-edit-branch',
  templateUrl: './add-edit-branch.component.html',
  styleUrls: ['./add-edit-branch.component.css']
})
export class AddEditBranchComponent implements OnInit {
  branchForm!: FormGroup;
  isEditMode = false;
  branchId?: number;

  constructor(
    private fb: FormBuilder,
    private branchService: BranchService,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.branchForm = this.fb.group({
      title: ['', [Validators.required, Validators.maxLength(200)]],
      openingHour: ['', Validators.required],
      closingHour: ['', Validators.required],
      managerName: ['', [Validators.required, Validators.maxLength(250)]],
    });

    this.route.params.subscribe((params) => {
      if (params['id']) {
        this.isEditMode = true;
        this.branchId = +params['id'];
        this.branchService.getBranchById(this.branchId).subscribe((branch) => {
          this.branchForm.patchValue(branch);
        });
      }
    });
  }

  onSubmit(): void {
    if (this.branchForm.valid) {
      const branchData = this.branchForm.value;
      const openingHour = this.convertToTimeSpan(branchData.openingHour);
      const closingHour = this.convertToTimeSpan(branchData.closingHour);

      branchData.openingHour = openingHour;
      branchData.closingHour = closingHour;

      if (this.isEditMode) {
        this.branchService.updateBranch(this.branchId!, branchData).subscribe(
          () => {
            this.router.navigate(['/branches']);
          },
          (error) => {
            this.handleErrors(error);
          }
        );
      } else {
        this.branchService.addBranch(branchData).subscribe(
          () => {
            this.router.navigate(['/branches']);
          },
          (error) => {
            this.handleErrors(error);
          }
        );
      }
    }
  }

  convertToTimeSpan(time: string): string {
    const [hours, minutes] = time.split(':');
    return `${hours}:${minutes}:00`;
  }
  handleErrors(error: any): void {
    if (error.status === 400 && error.error.errors) {
      const formErrors = error.error.errors;
      Object.keys(formErrors).forEach((field) => {
        const errorFieldName = field.toLowerCase(); 

        Object.keys(this.branchForm.controls).forEach((controlName) => {
          if (controlName.toLowerCase() === errorFieldName) {
            const control = this.branchForm.get(controlName);
            if (control) {
              control.setErrors({ serverError: formErrors[field].join(', ') });
            }
          }
        });
      });
    }
  }

}
