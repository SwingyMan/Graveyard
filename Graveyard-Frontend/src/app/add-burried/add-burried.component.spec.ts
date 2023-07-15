import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddBurriedComponent } from './add-burried.component';

describe('AddBurriedComponent', () => {
  let component: AddBurriedComponent;
  let fixture: ComponentFixture<AddBurriedComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddBurriedComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddBurriedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
