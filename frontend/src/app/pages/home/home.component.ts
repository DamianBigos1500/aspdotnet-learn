import { Component } from '@angular/core';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { ICourse } from '@app/features/courses/interfaces/ICourse';
import { CourseService } from '@app/features/courses/service/course.service';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss',
})
export class HomeComponent {
  public courses: ICourse[] = [];
  public isLoading: boolean = true;

  constructor(private courseService: CourseService) {}

  ngOnInit() {
    this.courseService.getCourse().subscribe({
      next: (courses) => {
        this.courses = courses;
      },
      error: (error) => {
        console.log(error);
      },
    });
  }
}
