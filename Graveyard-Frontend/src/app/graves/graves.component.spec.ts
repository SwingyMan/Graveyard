import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GravesComponent } from './graves.component';

describe('GravesComponent', () => {
  let component: GravesComponent;
  let fixture: ComponentFixture<GravesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GravesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GravesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
