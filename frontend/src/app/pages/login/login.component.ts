import { Component } from '@angular/core';
import {
  ReactiveFormsModule,
  FormBuilder,
  FormGroup,
  Validators,
} from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { AuthService } from '@app/core/services/auth.service';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [RouterLink, ReactiveFormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss',
})
export class LoginComponent {
  form!: FormGroup;

  constructor(
    private authService: AuthService,
    private fb: FormBuilder,
    private router: Router
  ) {}

  onSubmit(): void {
    if (this.form.valid) {
      const { email, password } = this.form.value;
      this.authService.login({ email, password }).subscribe({
        next: (response) => {
          // this.matSnackBar.open(response.message, 'Close', {
          //   duration: 5000,
          //   horizontalPosition: 'center',
          // });
          this.router.navigate(['/']);
        },
        error: (error) => {
          // this.matSnackBar.open(error.error.message, 'Close', {
          //   duration: 5000,
          //   horizontalPosition: 'center',
          // });
        },
      });
    }
  }

  ngOnInit(): void {
    this.form = this.fb.group({
      email: ['', [Validators.required]],
      password: ['', Validators.required],
    });
  }
}
