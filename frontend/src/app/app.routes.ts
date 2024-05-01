import { Routes } from '@angular/router';
import { LoginComponent } from './pages/login/login.component';
import { HomeComponent } from './pages/home/home.component';
import { CourseDetailsComponent } from './pages/courses/course-details/course-details.component';
import { CourseDetailsResolverService } from './pages/courses/course-details/course-details.resolver';

export const routes: Routes = [
  { path: 'login', component: LoginComponent },
  {
    path: 'courses/:id',
    component: CourseDetailsComponent,
    resolve: {
      courseData: CourseDetailsResolverService,
    },
  },
  {
    path: '',
    component: HomeComponent,
    resolve: {
      // courses: CommentResolver,
    },
  },
];
