import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserNotActiveComponent } from './user-not-active.component';

describe('UserNotActiveComponent', () => {
  let component: UserNotActiveComponent;
  let fixture: ComponentFixture<UserNotActiveComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UserNotActiveComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UserNotActiveComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
