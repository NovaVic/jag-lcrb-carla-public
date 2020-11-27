﻿Feature: CombinedCateringCRSApplications
    As a logged in business user
    I want to submit a CRS and Catering application for the same account

@cannabis @catering @crsapp
Scenario: Combined Catering and CRS Applications
    Given I am logged in to the dashboard as a private corporation
    And I click on the Start Application button for a Cannabis Retail Store
    And I complete the eligibility disclosure
    And I review the account profile for a private corporation
    And I review the organization structure for a private corporation
    And I click on the button for Submit Organization Information
    And I complete the Cannabis Retail Store application for a private corporation
    And I review the security screening requirements for a private corporation
    And I click on the button for Pay for Application
    And I enter the payment information
    And I confirm the payment receipt for a Cannabis Retail Store application
    And I click on the Dashboard tab
    And I click on the Start Application button for Catering
    And I click on the button for Continue to Organization Review
    And I click on the button for Submit Organization Information
    And I complete the Catering application
    And I click on the Submit button
    And I review the security screening requirements for a private corporation
    And I click on the button for Pay for Application
    And I enter the payment information
    And I confirm the payment receipt for a Catering application
    And the account is deleted
    Then I see the login page