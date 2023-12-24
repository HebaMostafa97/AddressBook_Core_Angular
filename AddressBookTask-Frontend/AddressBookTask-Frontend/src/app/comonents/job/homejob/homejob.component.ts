import { Component, OnInit } from '@angular/core';
import { JobService } from 'src/app/services/job.service';

@Component({
  selector: 'app-homejob',
  templateUrl: './homejob.component.html',
  styleUrls: ['./homejob.component.scss']
})
export class HomejobComponent implements OnInit {

  jobs:any[]=[];
  term:any='';

  constructor(private _jobService:JobService) { }

  GetJobs(){
    this._jobService.getJobs().subscribe((data)=>{
      this.jobs=data;
      console.log(this.jobs);
    })
  }

  ngOnInit(): void {
    this.GetJobs();
  }

}
