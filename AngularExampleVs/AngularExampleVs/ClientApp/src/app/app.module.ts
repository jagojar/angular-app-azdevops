import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { BlogPostsComponent } from './blog-posts/blog-posts.component';
import { BlogPostComponent } from './blog-post/blog-post.component';
import { BlogPostAddEditComponent } from './blog-post-add-edit/blog-post-add-edit.component';
import { BlogPostService } from './services/blog-post.service';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    BlogPostsComponent,
    BlogPostComponent,
    BlogPostAddEditComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },      
      { path: 'blogpost', component: BlogPostsComponent },
      { path: 'blogpost/add', component: BlogPostAddEditComponent },
      { path: 'blogpost/:id', component: BlogPostComponent },
      { path: 'blogpost/edit/:id', component: BlogPostAddEditComponent },      
    ])
  ],
  providers: [
    BlogPostService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
