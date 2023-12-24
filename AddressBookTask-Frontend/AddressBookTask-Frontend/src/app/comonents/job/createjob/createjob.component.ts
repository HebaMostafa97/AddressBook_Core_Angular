import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { JobService } from 'src/app/services/job.service';

@Component({
  selector: 'app-createjob',
  templateUrl: './createjob.component.html',
  styleUrls: ['./createjob.component.scss']
})
export class CreatejobComponent implements OnInit {

  constructor( private _Router:Router , private _jobService: JobService ) { }

  CreateJob:FormGroup=new FormGroup({
    'Name':new FormControl(null,[Validators.required]),
  })

  Create(){
   
    if(this.CreateJob.invalid){
      return;
    }
    
    this._jobService.createJob(this.CreateJob.value).subscribe((res)=>{
      console.log(res)
      this._Router.navigateByUrl("/Homejob");
    })
  }

  ngOnInit(): void {
  }

}
