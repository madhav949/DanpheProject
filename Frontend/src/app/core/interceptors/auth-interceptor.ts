import { Injectable } from '@angular/core';
import { Role } from '../enums/role';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  // 🔥 Change role here to test
  private currentRole: Role = Role.Admin;

  getUserRole(): Role {
    return this.currentRole;
  }

  isAdmin(): boolean {
    return this.currentRole === Role.Admin;
  }
}