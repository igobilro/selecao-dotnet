import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SigninComponent } from './components/signin/signin.component';
import { RegisterComponent } from './components/register/register.component';
import { CursosComponent } from './components/cursos/cursos.component';
import { MatriculasComponent } from './components/matriculas/matriculas.component';
import { PerfilComponent } from './components/perfil/perfil.component';
import { AuthGuard } from './auth/auth.guard';


const routes: Routes = [
  {path: '',pathMatch: 'full', redirectTo: 'register'},
  {path: 'signin', component: SigninComponent},
  {path: 'register', component: RegisterComponent},
  {path: 'cursos', component: CursosComponent, canActivate:[AuthGuard]},
  {path: 'perfil', component: PerfilComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
