import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddGravediggerComponent } from './add-gravedigger.component';

describe('AddGravediggerComponent', () => {
  let component: AddGravediggerComponent;
  let fixture: ComponentFixture<AddGravediggerComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AddGravediggerComponent]
    });
    fixture = TestBed.createComponent(AddGravediggerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
