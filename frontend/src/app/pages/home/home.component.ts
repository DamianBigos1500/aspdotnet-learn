import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ICourse } from '@app/features/courses/interfaces/ICourse';
import { CourseService } from '@app/features/courses/service/course.service';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [],
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss',
})
export class HomeComponent {
  public courses: ICourse[] = [];

  constructor(private courseService: CourseService) {}

  ngOnInit() {
    this.courseService.getCourse().subscribe((courses) => {
      this.courses = courses;
    });
  }
}
