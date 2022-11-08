import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DrzaveComponent } from './drzave.component';

describe('DrzaveComponent', () => {
  let component: DrzaveComponent;
  let fixture: ComponentFixture<DrzaveComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DrzaveComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DrzaveComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
