import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { JobService } from 'src/app/services/job.service';

@Component({
  selector: 'app-updatejob',
  templateUrl: './updatejob.component.html',
  styleUrls: ['./updatejob.component.scss']
})
export class UpdatejobComponent implements OnInit {
  oldJob:any;
  id:any;
  
  constructor( private _Router:Router , private _jobService: JobService ,  private _ActivatedRoute:ActivatedRoute ) { }

  UpdateJob:FormGroup=new FormGroup({
    'Id':new FormControl(null),
    'Name':new FormControl(null,[Validators.required]),
  })

  Update(){
    if(this.UpdateJob.invalid&& this.UpdateJob.get("Id")!=this.oldJob.id){
      return;
    }
    this._jobService.UpdateJob(this.UpdateJob.value).subscribe((res)=>{
      this._Router.navigateByUrl("/Homejob");

    })
  }
  getJob(){
    this.id=this._ActivatedRoute.snapshot.paramMap.get('id');
    this._jobService.getJobById(this.id).subscribe((data)=>{
      this.oldJob=data;
      console.log(this.oldJob);
      this.UpdateJob.get("Id")?.setValue(this.oldJob.id);
      this.UpdateJob.get("Name")?.setValue(this.oldJob.name);
    })

  }

  ngOnInit(): void {
    this.getJob();
  }

}
