import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PlannedBurrialsListComponent } from './planned-burrials-list.component';

describe('PlannedBurrialsListComponent', () => {
  let component: PlannedBurrialsListComponent;
  let fixture: ComponentFixture<PlannedBurrialsListComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [PlannedBurrialsListComponent]
    });
    fixture = TestBed.createComponent(PlannedBurrialsListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
