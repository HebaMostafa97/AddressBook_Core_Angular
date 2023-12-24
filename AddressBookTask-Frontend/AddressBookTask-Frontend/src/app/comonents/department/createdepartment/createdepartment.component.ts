import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { DepartmentService } from 'src/app/services/department.service';

@Component({
  selector: 'app-createdepartment',
  templateUrl: './createdepartment.component.html',
  styleUrls: ['./createdepartment.component.scss']
})
export class CreatedepartmentComponent implements OnInit {

  constructor( private _Router:Router , private _DepartmentService: DepartmentService ) { }

  CreateDepartment:FormGroup=new FormGroup({
    'Name':new FormControl(null,[Validators.required]),
  })

  Create(){
    if(this.CreateDepartment.invalid){
      return;
    }
    
    this._DepartmentService.createDepartment(this.CreateDepartment.value).subscribe((res)=>{
      console.log(res)
      this._Router.navigateByUrl("/Homedepartment");
    })
  }

  ngOnInit(): void {
  }

}
