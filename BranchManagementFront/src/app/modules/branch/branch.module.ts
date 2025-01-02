import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BranchListComponent } from './components/branch-list/branch-list.component';
import { AddEditBranchComponent } from './components/add-edit-branch/add-edit-branch.component';
import { BranchService } from './services/branch.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    BranchListComponent,
    AddEditBranchComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
   
  ],
  exports: [BranchListComponent,
    AddEditBranchComponent]
})
export class BranchModule { }
