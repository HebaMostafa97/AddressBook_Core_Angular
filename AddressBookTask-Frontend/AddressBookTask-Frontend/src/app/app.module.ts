import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

////////// Components //////////
import { AppComponent } from './app.component';
import { SearchPipe } from './pipes/search.pipe';
import { NavbarComponent } from './comonents/navbar/navbar.component';
import { LoginComponent } from './comonents/login/login.component';
import { RegisterComponent } from './comonents/register/register.component';
import { NotfoundComponent } from './comonents/notfound/notfound.component';
////////// AddressBook //////////
import { HomeaddressbookComponent } from './comonents/addressbook/homeaddressbook/homeaddressbook.component';
import { CreateaddressbookComponent } from './comonents/addressbook/createaddressbook/createaddressbook.component';
import { UpdateaddressbookComponent } from './comonents/addressbook/updateaddressbook/updateaddressbook.component';
import { DeleteaddressbookComponent } from './comonents/addressbook/deleteaddressbook/deleteaddressbook.component';
////////// Department //////////
import { HomedepartmentComponent } from './comonents/department/homedepartment/homedepartment.component';
import { CreatedepartmentComponent } from './comonents/department/createdepartment/createdepartment.component';
import { UpdatedepartmentComponent } from './comonents/department/updatedepartment/updatedepartment.component';
import { DeletedepartmentComponent } from './comonents/department/deletedepartment/deletedepartment.component';
/////////// Job ////////////
import { HomejobComponent } from './comonents/job/homejob/homejob.component';
import { CreatejobComponent } from './comonents/job/createjob/createjob.component';
import { UpdatejobComponent } from './comonents/job/updatejob/updatejob.component';
import { DeletejobComponent } from './comonents/job/deletejob/deletejob.component';

@NgModule({
  declarations: [
    AppComponent,
    SearchPipe,
    NavbarComponent,
    LoginComponent,
    RegisterComponent,
    NotfoundComponent,
    HomeaddressbookComponent,
    CreateaddressbookComponent,
    UpdateaddressbookComponent,
    DeleteaddressbookComponent,
    HomedepartmentComponent,
    CreatedepartmentComponent,
    UpdatedepartmentComponent,
    DeletedepartmentComponent,
    HomejobComponent,
    CreatejobComponent,
    UpdatejobComponent,
    DeletejobComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
