import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AddressbookService } from 'src/app/services/addressbook.service';
import { DepartmentService } from 'src/app/services/department.service';
import { JobService } from 'src/app/services/job.service';

@Component({
  selector: 'app-createaddressbook',
  templateUrl: './createaddressbook.component.html',
  styleUrls: ['./createaddressbook.component.scss']
})
export class CreateaddressbookComponent implements OnInit {

  jobs:any[]=[];
  Departments:any[]=[];
  image:any;
  error:any;

  constructor(private _AddressbookService :AddressbookService , private _Router:Router , private _jobService:JobService , private _DepartmentService:DepartmentService) {}
  
  CreateAddressBook:FormGroup=new FormGroup({
    'FullName':new FormControl(null,[Validators.required]),
    'JobId':new FormControl(null,[Validators.required]),
    'DepartmentId':new FormControl(null,[Validators.required]), 
    'MobileNumber':new FormControl(null,[Validators.required , Validators.pattern(/^01[0125][0-9]{8}$/)]),
    'DateOfBirth':new FormControl(null),
    'Address':new FormControl(null),
    'Email':new FormControl(null,[Validators.required,Validators.email]),
    'Password':new FormControl(null,[Validators.required]),
    'Photo':new FormControl(null),
    'Age':new FormControl(null,[Validators.required]),
  })

  SelectFile(e: any) {
    this.image = e.target.files[0];
    this.CreateAddressBook.patchValue({
      'Photo': this.image
    });
  }

  Create(){
    if(this.CreateAddressBook.invalid){
      return;
    }
    let formData = new FormData();
    formData.append('FullName', this.CreateAddressBook.controls['FullName'].value);
    formData.append('JobId', this.CreateAddressBook.controls['JobId'].value);
    formData.append('DepartmentId', this.CreateAddressBook.controls['DepartmentId'].value);
    formData.append('MobileNumber', this.CreateAddressBook.controls['MobileNumber'].value);
    formData.append('DateOfBirth', this.CreateAddressBook.controls['DateOfBirth'].value);
    formData.append('Address', this.CreateAddressBook.controls['Address'].value);
    formData.append('Email', this.CreateAddressBook.controls['Email'].value);
    formData.append('Password', this.CreateAddressBook.controls['Password'].value);
    formData.append('Photo', this.CreateAddressBook.controls['Photo'].value);
    formData.append('Age', this.CreateAddressBook.controls['Age'].value);
    console.log(formData);
    this._AddressbookService.createAddressBook(formData).subscribe((res)=>{
      console.log(res)
      this._Router.navigateByUrl("/Homeaddressbook");
    },(error)=>{
      this.error = error.error.errors[0];
      console.log(error.error.errors[0]);
    }
    
    );
  }

  GetJobs(){
    this._jobService.getJobs().subscribe((data)=>{
      this.jobs=data;
      console.log(this.jobs);
    })
  }

  GetDepartments(){
   
    this._DepartmentService.getDepartments().subscribe((data)=>{
      this.Departments=data;
      console.log(this.Departments);
    })
  }


  ngOnInit(): void {
    this.GetDepartments();
    this.GetJobs();
  }

}
