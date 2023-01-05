import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SrijedaComponent } from './srijeda.component';

describe('SrijedaComponent', () => {
  let component: SrijedaComponent;
  let fixture: ComponentFixture<SrijedaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SrijedaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SrijedaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
