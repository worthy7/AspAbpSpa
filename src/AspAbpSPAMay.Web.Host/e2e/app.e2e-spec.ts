import { AspAbpSPAMayTemplatePage } from './app.po';

describe('AspAbpSPAMay App', function() {
  let page: AspAbpSPAMayTemplatePage;

  beforeEach(() => {
    page = new AspAbpSPAMayTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
