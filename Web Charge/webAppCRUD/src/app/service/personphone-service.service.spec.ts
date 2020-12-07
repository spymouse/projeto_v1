import { TestBed } from '@angular/core/testing';

import { PersonphoneServiceService } from './personphone-service.service';

describe('PersonphoneServiceService', () => {
  let service: PersonphoneServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PersonphoneServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
