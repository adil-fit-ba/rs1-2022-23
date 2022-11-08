import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OpstineComponent } from './opstine.component';

describe('OpstineComponent', () => {
  let component: OpstineComponent;
  let fixture: ComponentFixture<OpstineComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OpstineComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(OpstineComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
