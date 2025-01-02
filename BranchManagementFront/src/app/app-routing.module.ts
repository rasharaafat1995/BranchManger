import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
//import { BranchListComponent } from './modules/branch/branch.module';
import { AddEditBranchComponent } from './modules/branch/components/add-edit-branch/add-edit-branch.component';
import { BranchListComponent } from './modules/branch/components/branch-list/branch-list.component';
import { BookingComponent } from './modules/booking/booking/booking.component';
import { LoginComponent } from './login/login.component';

const routes: Routes = [
 // { path: '', component: BookingComponent }, 
  { path: '', component: BranchListComponent }, 
  { path: 'login', component: LoginComponent },

  { path: 'branches', component: BranchListComponent },
  { path: 'add-branch', component: AddEditBranchComponent  },
  { path: 'edit-branch/:id', component: AddEditBranchComponent },
  { path: '**', redirectTo: '' } 
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
