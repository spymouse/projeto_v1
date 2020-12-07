import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PersonphonelistComponent } from './personphonelist.component';



describe('PersonphonelistComponent', () => {
  let component: PersonphonelistComponent;
  let fixture: ComponentFixture<PersonphonelistComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PersonphonelistComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PersonphonelistComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
