import { Component, OnInit } from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';

import { UNITS } from '../../constants/units';
import { UnitsEnum } from '../../enums/units.enum';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss'],
})
export class HeaderComponent implements OnInit {
  public units: typeof UNITS = UNITS;
  public unitsTitles: typeof UnitsEnum = UnitsEnum;
  public menuIsActive = false;
  public currentPath: string | undefined;
  public unitsEnum = UnitsEnum;

  public constructor(public router: Router) {}

  public ngOnInit(): void {
    this.changePath();
  }

  public changePath(): void {
    this.router.events.subscribe((event: any) => {
      if (event instanceof NavigationEnd) {
        this.currentPath = this.router.url.slice(1);
        console.log(this.currentPath);
      }
    });
  }

  public toggleMenu(): void {
    this.menuIsActive = !this.menuIsActive;
  }
}
