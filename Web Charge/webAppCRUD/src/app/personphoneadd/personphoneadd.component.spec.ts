import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PersonphoneaddComponent } from './personphoneadd.component';

describe('PersonphoneaddComponent', () => {
  let component: PersonphoneaddComponent;
  let fixture: ComponentFixture<PersonphoneaddComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PersonphoneaddComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PersonphoneaddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
