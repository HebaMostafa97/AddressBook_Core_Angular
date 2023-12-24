import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
//////////////// Addressbook ////////////////////
import { HomeaddressbookComponent } from './comonents/addressbook/homeaddressbook/homeaddressbook.component';
import { CreateaddressbookComponent } from './comonents/addressbook/createaddressbook/createaddressbook.component';
import { DeleteaddressbookComponent } from './comonents/addressbook/deleteaddressbook/deleteaddressbook.component';
import { UpdateaddressbookComponent } from './comonents/addressbook/updateaddressbook/updateaddressbook.component';
/////////////// Departments /////////////////
import { HomedepartmentComponent } from './comonents/department/homedepartment/homedepartment.component';
import { CreatedepartmentComponent } from './comonents/department/createdepartment/createdepartment.component';
import { DeletedepartmentComponent } from './comonents/department/deletedepartment/deletedepartment.component';
import { UpdatedepartmentComponent } from './comonents/department/updatedepartment/updatedepartment.component';
////////////// Jobs //////////////////////
import { HomejobComponent } from './comonents/job/homejob/homejob.component';
import { CreatejobComponent } from './comonents/job/createjob/createjob.component';
import { DeletejobComponent } from './comonents/job/deletejob/deletejob.component';
import { UpdatejobComponent } from './comonents/job/updatejob/updatejob.component';

import { NotfoundComponent } from './comonents/notfound/notfound.component';
import { AuthGuardService } from './services/auth-guard.service';
import { LoginComponent } from './comonents/login/login.component';
import { RegisterComponent } from './comonents/register/register.component';


const routes: Routes = 
[
  {path:'',redirectTo:'Homeaddressbook',pathMatch:'full'},
  ////////////////// addressbook ///////////////
  {path:'Homeaddressbook',component:HomeaddressbookComponent ,canActivate:[AuthGuardService]},
  {path:'Createaddressbook',component:CreateaddressbookComponent,canActivate:[AuthGuardService]},
  {path:'Deleteaddressbook/:id',component:DeleteaddressbookComponent,canActivate:[AuthGuardService]},
  {path:'Updateaddressbook/:id',component:UpdateaddressbookComponent,canActivate:[AuthGuardService]},
  
  ////////////////// Department ///////////////
  {path:'Homedepartment',component:HomedepartmentComponent,canActivate:[AuthGuardService]},
  {path:'Createdepartment',component:CreatedepartmentComponent,canActivate:[AuthGuardService]},
  {path:'Updatedepartment/:id',component:UpdatedepartmentComponent,canActivate:[AuthGuardService]},
  {path:'Deletedepartment/:id',component:DeletedepartmentComponent,canActivate:[AuthGuardService]},

  ////////////////// Job ///////////////////
  {path:'Homejob',component:HomejobComponent,canActivate:[AuthGuardService]},
  {path:'Createjob',component:CreatejobComponent,canActivate:[AuthGuardService]},
  {path:'Updatejob/:id',component:UpdatejobComponent,canActivate:[AuthGuardService]},
  {path:'Deletejob/:id',component:DeletejobComponent,canActivate:[AuthGuardService]},

  {path:'login',component:LoginComponent},
  {path:'register',component:RegisterComponent},
  {path:'**',component:NotfoundComponent},

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
