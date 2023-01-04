import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TwoFOtkljucajComponent } from './two-f-otkljucaj.component';

describe('TwoFOtkljucajComponent', () => {
  let component: TwoFOtkljucajComponent;
  let fixture: ComponentFixture<TwoFOtkljucajComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TwoFOtkljucajComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TwoFOtkljucajComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
