/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { AuthGuardsVendaService } from './AuthGuardsVenda.service';

describe('Service: AuthGuardsVenda', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AuthGuardsVendaService]
    });
  });

  it('should ...', inject([AuthGuardsVendaService], (service: AuthGuardsVendaService) => {
    expect(service).toBeTruthy();
  }));
});
