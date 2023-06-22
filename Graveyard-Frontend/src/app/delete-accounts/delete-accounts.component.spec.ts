import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeleteAccountsComponent } from './delete-accounts.component';

describe('DeleteAccountsComponent', () => {
  let component: DeleteAccountsComponent;
  let fixture: ComponentFixture<DeleteAccountsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DeleteAccountsComponent]
    });
    fixture = TestBed.createComponent(DeleteAccountsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
