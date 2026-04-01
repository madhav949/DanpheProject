import { Component, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { AuthService } from '../../../core/interceptors/auth-interceptor';
import { Role } from '../../../core/enums/role';

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './navbar.html',
  styleUrls: ['./navbar.css']
})

export class NavbarComponent {
  username = signal('MJ'); // placeholder, will bind to logged-in user later
   constructor(private authService: AuthService) {}

  get role(): Role {
    return this.authService.getUserRole();
  }
}