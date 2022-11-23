import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GraphMaleFemaleComponent } from './graph-male-female.component';

describe('GraphMaleFemaleComponent', () => {
  let component: GraphMaleFemaleComponent;
  let fixture: ComponentFixture<GraphMaleFemaleComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GraphMaleFemaleComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GraphMaleFemaleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
