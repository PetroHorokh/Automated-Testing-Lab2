Feature: SearchCustomer

@search_customer
Scenario Outline: Find customer by specific data
	Given name/surname/account number - <data>
	Then you should have <customer name>, <customer surname> and <account number>

	Examples:
    | data  | customer name | customer surname | account number |
    | harry | Harry         | Potter           | 1004 1005 1006 |
    | ille  | Neville       | Longbottom       | 1013 1014 1015 |
    | 1010  | Albus         | Dumbledore       | 1010 1011 1012 |

@search_empty_output
Scenario Outline: Empty output when incorrect data
    Given name/surname/account number - <data>
    Then should have empty

    Examples: 
    | data     |
    | dasda    |
    | 31231231 |

@search_multiple_customers
Scenario Outline: Find multiple customers
    Given name/surname/account number - <data>
    Then should have account numbers <account number 1> and <account number 2>

    Examples: 
    | data | account number 1 | account number 2 |
    | i    | 1001 1002 1003   | 1013 1014 1015   |
    | y    | 1004 1005 1006   | 1007 1008 1009   |