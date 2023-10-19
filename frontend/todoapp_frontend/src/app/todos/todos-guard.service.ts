import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Router } from '@angular/router';

@Injectable({
  providedIn: 'root',
})
export class TodosGuardService {
  constructor(private router: Router) {}

  async canActivate(router: ActivatedRouteSnapshot) {
    this.router.navigate(['/login']);
    return false;
  }
}
