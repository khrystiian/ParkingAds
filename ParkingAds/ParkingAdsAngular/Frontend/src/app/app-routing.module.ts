import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdComponent } from './components/ad/ad.component';
import { WelcomeComponent } from './components/welcome/welcome.component';

const routes: Routes = [
  {path: 'ads', component: AdComponent},
  {path: '', component: WelcomeComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
