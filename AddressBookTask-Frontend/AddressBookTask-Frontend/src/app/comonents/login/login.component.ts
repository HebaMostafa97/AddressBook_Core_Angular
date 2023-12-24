import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  error:any;
  constructor(private _AuthService: AuthService , private _Router : Router ) { }
  
  loginForm:FormGroup=new FormGroup({
    'email':new FormControl(null ,[Validators.required,Validators.email]),
    'password':new FormControl(null ,[Validators.required]),
  })

  Login(){
    if(this.loginForm.invalid){
      return; 
    }
    this._AuthService.signIn(this.loginForm.value).subscribe((data)=>{
      console.log(data);

      if(data.token){
        console.log("success");
        localStorage.setItem("token",data.token);
        this.error=null;
        this._Router.navigateByUrl("/Homeaddressbook");
      }else{
         alert(data.message);
         this.loginForm.reset();
      }
    },(error)=>{
      this.error="user name or password is invalid";
      console.log(error);
    }
    
    );
  }


  ngOnInit(): void {
  }

}
