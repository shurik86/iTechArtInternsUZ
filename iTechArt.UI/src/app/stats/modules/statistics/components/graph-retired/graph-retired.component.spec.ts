import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GraphRetiredComponent } from './graph-retired.component';

describe('GraphRetiredComponent', () => {
  let component: GraphRetiredComponent;
  let fixture: ComponentFixture<GraphRetiredComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GraphRetiredComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GraphRetiredComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
