import { Component, OnInit } from '@angular/core';
import { DepartmentService } from 'src/app/services/department.service';

@Component({
  selector: 'app-homedepartment',
  templateUrl: './homedepartment.component.html',
  styleUrls: ['./homedepartment.component.scss']
})
export class HomedepartmentComponent implements OnInit {

  departments:any[]=[];
  term:any='';
  startDate:any;
  endDate:any;

  constructor(private _DepartmentService:DepartmentService) { }

  GetDepartments(){
    this._DepartmentService.getDepartments().subscribe((data)=>{
      this.departments=data;
      console.log(this.departments);
    })
  }

  
  ngOnInit(): void {
  }

}
