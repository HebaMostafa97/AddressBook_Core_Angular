import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { DepartmentService } from 'src/app/services/department.service';

@Component({
  selector: 'app-deletedepartment',
  templateUrl: './deletedepartment.component.html',
  styleUrls: ['./deletedepartment.component.scss']
})
export class DeletedepartmentComponent implements OnInit {

  oldDepartment:any;
  id:any;

  constructor( private _Router:Router , private _DepartmentService: DepartmentService ,  private _ActivatedRoute:ActivatedRoute ) { }

  DeleteDepartment:FormGroup=new FormGroup({
    'Id':new FormControl({value:'',disabled:true}),
    'Name':new FormControl({value:'',disabled:true},[Validators.required]),
  })

  Delete(){
    if(this.DeleteDepartment.invalid&& this.DeleteDepartment.get("Id")!=this.oldDepartment.id){
      return;
    }
    this._DepartmentService.DeleteDepartment(this.DeleteDepartment.value).subscribe((res)=>{
      this._Router.navigateByUrl("/Homedepartment");

    })
  }

  getDepartment(){
    this.id=this._ActivatedRoute.snapshot.paramMap.get('id');
    this._DepartmentService.getDepartmentById(this.id).subscribe((data)=>{
      this.oldDepartment=data;
      console.log(this.oldDepartment);
      this.DeleteDepartment.get("Id")?.setValue(this.oldDepartment.id);
      this.DeleteDepartment.get("Name")?.setValue(this.oldDepartment.name);
    })

  }

  ngOnInit(): void {
    this.getDepartment();
  }

}
