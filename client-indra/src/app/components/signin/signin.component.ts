import { Component, OnInit } from '@angular/core';
import { FormGroup, NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from 'src/app/shared/user.service';

@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html',
  styleUrls: ['./signin.component.css']
})
export class SigninComponent implements OnInit {
  

  constructor(public service:UserService, private router:Router) { }

  ngOnInit(): void {
    if(localStorage.getItem('User_Token') != null)
      this.router.navigate(['/cursos'])
  }

  submitForm(){
    this.service.login().subscribe(
      (res:any) => {
        localStorage.setItem('User_Token',res.User_Token);
        this.router.navigateByUrl('/cursos');
      },
      err => {
        if(err.status == 400){
          console.log("Usuário ou senha inválido")
        }
      }
    )
  }

}
