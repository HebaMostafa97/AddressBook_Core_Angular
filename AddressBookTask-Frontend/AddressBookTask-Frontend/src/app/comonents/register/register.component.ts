import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  error:any;

  constructor(private _AuthService: AuthService , private _Router:Router) { }

  registerForm:FormGroup=new FormGroup({
    'displayName':new FormControl(null ,[Validators.required,Validators.minLength(3),Validators.maxLength(10)]),
    'phoneNumber':new FormControl(null ,[Validators.required,Validators.pattern(/^01[0125][0-9]{8}$/)]),
    'email':new FormControl(null ,[Validators.required,Validators.email]),
    'password':new FormControl(null ,[Validators.required,Validators.pattern(/^(?=.*[^a-zA-Z0-9])(?=.*[A-Z]).{6,}$/)]),
  })
  
  register(){
    if(this.registerForm.invalid){
      return; 
    }

    this._AuthService.signUp(this.registerForm.value).subscribe((data)=>{
      this.error=null;
      console.log(data);
      if(data.token){
        this._Router.navigateByUrl("/login");
      }else{
        alert(data.message);
         this.registerForm.reset();
      }
    },(error)=>{
      this.error = error.error.errors[0];
      console.log(error.error.errors[0]);
    }
    
    );
  }

  

  ngOnInit(): void {
  }

}
