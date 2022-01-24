import { Component, OnInit } from '@angular/core';
import { RouterLink, RouterLinkActive } from '@angular/router';
import { MatButton } from '@angular/material/button';
import { MatButtonModule } from '@angular/material/button';
import { AppService } from './app.service';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Alunos } from './alunos';
import { Observable } from 'rxjs';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  readonly rootURL = 'https://localhost:44345/api';
  title = 'client-indra';

  alunos: any;

  constructor(private http : HttpClient){}
  ngOnInit(): void {}

}