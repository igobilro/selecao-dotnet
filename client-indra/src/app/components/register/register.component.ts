import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AppComponent } from 'src/app/app.component';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { UserService } from 'src/app/shared/user.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  readonly rootURL = 'https://localhost:44345/api';

  constructor(public service: UserService) { 
   }

  ngOnInit(): void { 
    this.service.form.reset();
   }

   submitForm(){
     this.service.register().subscribe(
       (res: any) =>{
         if (res.recceded){
           this.service.form.reset();
         }
       },

       err => {
         console.log(err);
       }
     )
   }
  }
