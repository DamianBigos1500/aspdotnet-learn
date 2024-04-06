import { Injectable } from '@angular/core';
import {
  ActivatedRouteSnapshot,
  Resolve,
  RouterStateSnapshot,
} from '@angular/router';
import { CourseService } from '@app/features/courses/service/course.service';

@Injectable({ providedIn: 'root' })
export class CommentResolver {
  constructor(private courseService: CourseService) {}

  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    return this.courseService.getCourse();
  }
}
