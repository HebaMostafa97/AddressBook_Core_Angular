import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { JobService } from 'src/app/services/job.service';

@Component({
  selector: 'app-deletejob',
  templateUrl: './deletejob.component.html',
  styleUrls: ['./deletejob.component.scss']
})
export class DeletejobComponent implements OnInit {

  oldJob:any;
  id:any;

  constructor( private _Router:Router , private _jobService: JobService ,  private _ActivatedRoute:ActivatedRoute ) { }

  DeleteJob:FormGroup=new FormGroup({
    'Id':new FormControl({value:'',disabled:true}),
    'Name':new FormControl({value:'',disabled:true},[Validators.required]),
  })

  Delete(){
    if(this.DeleteJob.invalid&& this.DeleteJob.get("Id")!=this.oldJob.id){
      return;
    }
    this._jobService.DeleteJob(this.DeleteJob.value).subscribe((res)=>{
      this._Router.navigateByUrl("/Homejob");

    })
  }
  getJob(){
    this.id=this._ActivatedRoute.snapshot.paramMap.get('id');
    this._jobService.getJobById(this.id).subscribe((data)=>{
      this.oldJob=data;
      console.log(this.oldJob);
      this.DeleteJob.get("Id")?.setValue(this.oldJob.id);
      this.DeleteJob.get("Name")?.setValue(this.oldJob.name);
    })
  }

  ngOnInit(): void {
    this.getJob();
  }

}
