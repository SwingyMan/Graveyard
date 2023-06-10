import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddGraveComponent } from './add-grave.component';

describe('AddGraveComponent', () => {
  let component: AddGraveComponent;
  let fixture: ComponentFixture<AddGraveComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddGraveComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddGraveComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
