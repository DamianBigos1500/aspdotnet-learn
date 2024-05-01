import { Injectable, inject } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve } from '@angular/router';
import { CourseService } from '@app/features/courses/service/course.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
 
 
@Injectable({
  providedIn: 'root'
})
export class CourseDetailsResolverService implements Resolve<any> {
  public courseService = inject(CourseService);

  resolve(route: ActivatedRouteSnapshot): Observable<any> {
    return this.courseService.getCourseById(route.params['id']).pipe(
      catchError(error => {
        return of('No data');
      })
    );
  }
}