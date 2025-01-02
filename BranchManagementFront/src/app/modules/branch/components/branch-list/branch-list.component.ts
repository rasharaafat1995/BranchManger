import { Component, OnInit } from '@angular/core';
import { BranchService } from '../../services/branch.service';
import { Branch } from 'src/app/models/branch.model.model';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-branch-list',
  templateUrl: './branch-list.component.html',
  styleUrls: ['./branch-list.component.css']
})
export class BranchListComponent implements OnInit {
  branches: Branch[] = [];
  totalItems: number = 0;
  currentPage: number = 1;
  itemsPerPage: number = 3;
  searchQuery: string = '';
  totalPages = 0;
  constructor(private branchService: BranchService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.loadBranches();
  }

  loadBranches(): void {
    this.branchService
      .getBranches(this.searchQuery, this.currentPage, this.itemsPerPage)
      .subscribe((data: any) => {
        this.branches = data.branches;
        this.totalItems = data.totalItems;
        this.calculateTotalPages();

      });
  }
  calculateTotalPages(): void {
    this.totalPages = Math.ceil(this.totalItems / this.itemsPerPage);
  }
  searchBranches(): void {
    this.currentPage = 1; // Reset to the first page on new search
    this.loadBranches();
  }

  changePage(page: number): void {
    this.currentPage = page;
    this.loadBranches();
  }

  deleteBranch(id: number): void {
    if (confirm('Proceed with deleting this branch?')) {
      this.branchService.deleteBranch(id).subscribe(() => {
        this.loadBranches();
      });
    }
  }

  editBranch(branch: Branch): void {
    this.router.navigate(['/edit-branch', branch.id]);

  }

  navigateToAddBranch(): void {
    this.router.navigate(['/add-branch']);
  }

}
