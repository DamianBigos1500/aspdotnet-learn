import { Component, inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ICourse } from '@app/features/courses/interfaces/ICourse';
import { CourseService } from '@app/features/courses/service/course.service';

@Component({
  selector: 'app-course-details',
  standalone: true,
  imports: [],
  templateUrl: './course-details.component.html',
  styleUrl: './course-details.component.scss',
})
export class CourseDetailsComponent {
  public course!: ICourse;

  private courseService = inject(CourseService);
  private activatedRoute = inject(ActivatedRoute);

  ngOnInit() {
    this.activatedRoute.data.subscribe((response) => {
      this.course = response['courseData'];
    });
  }
}
