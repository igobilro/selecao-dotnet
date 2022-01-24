import { Injectable } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private fb:FormBuilder, private http: HttpClient) { }

  readonly rootAPI = 'https://localhost:44345/api';
  form = this.fb.group({
    name: [''],
    email: ['', Validators.email],
    senha: ['', Validators.required, Validators.minLength(8)],
    cpf: ['', Validators.required]
  })

  register(){
    var body = {
      Name: this.form.value.name,
      Email: this.form.value.email,
      Password: this.form.value.senha,
      CPF: this.form.value.cpf
    };

    return this.http.post(this.rootAPI + '/Alunos', body)
  }

  login(){

    var data = {
      Email: this.form.value.email,
      Password: '123456789'
    };
    
    return this.http.post(this.rootAPI + '/login', data)
  }
}
