import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
//import { BranchListComponent } from './modules/branch/branch.module';
import { AddEditBranchComponent } from './modules/branch/components/add-edit-branch/add-edit-branch.component';
import { BranchListComponent } from './modules/branch/components/branch-list/branch-list.component';
import { BookingComponent } from './modules/booking/booking/booking.component';
import { LoginComponent } from './login/login.component';
import { AuthGuard } from './services/auth.guard';

const routes: Routes = [
  
  { path: '', component: BookingComponent },
  { path: 'booking', component: BookingComponent },
  { path: 'login', component: LoginComponent },
  { path: 'branches', component: BranchListComponent, canActivate: [AuthGuard] },
  { path: 'add-branch', component: AddEditBranchComponent, canActivate: [AuthGuard] },
  { path: 'edit-branch/:id', component: AddEditBranchComponent, canActivate: [AuthGuard] },
  { path: '**', redirectTo: '' } 
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
