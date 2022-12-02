import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GraphFacultiesComponent } from './graph-faculties.component';

describe('GraphFacultiesComponent', () => {
  let component: GraphFacultiesComponent;
  let fixture: ComponentFixture<GraphFacultiesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GraphFacultiesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GraphFacultiesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
