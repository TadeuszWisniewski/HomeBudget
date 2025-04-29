using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeBudget.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BudgetDurations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BudgetDurations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BudgetTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BudgetTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Currency",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Sign = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExpenseSubsorts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseSubsorts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IncomeSubsource",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncomeSubsource", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(9,2)", precision: 9, scale: 2, nullable: false),
                    CurrencyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Budgets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BudgetTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BudgetDurationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(9,2)", precision: 9, scale: 2, nullable: false),
                    CurrencyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Budgets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Budgets_BudgetDurations_BudgetDurationId",
                        column: x => x.BudgetDurationId,
                        principalTable: "BudgetDurations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Budgets_BudgetTypes_BudgetTypeId",
                        column: x => x.BudgetTypeId,
                        principalTable: "BudgetTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Budgets_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(9,2)", precision: 9, scale: 2, nullable: false),
                    CurrencyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expenses_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Incomes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(9,2)", precision: 9, scale: 2, nullable: false),
                    CurrencyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incomes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Incomes_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExpenseSorts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExpenseSubsortId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseSorts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExpenseSorts_ExpenseSubsorts_ExpenseSubsortId",
                        column: x => x.ExpenseSubsortId,
                        principalTable: "ExpenseSubsorts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IncomeSources",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IncomeSubsourceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncomeSources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IncomeSources_IncomeSubsource_IncomeSubsourceId",
                        column: x => x.IncomeSubsourceId,
                        principalTable: "IncomeSubsource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_UserTypes_UserTypeId",
                        column: x => x.UserTypeId,
                        principalTable: "UserTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Debts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(9,2)", precision: 9, scale: 2, nullable: false),
                    CurrencyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Debts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Debts_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Debts_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currency",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BudgetExpense",
                columns: table => new
                {
                    BudgetsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExpenseSubsortsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BudgetExpense", x => new { x.BudgetsId, x.ExpenseSubsortsId });
                    table.ForeignKey(
                        name: "FK_BudgetExpense_Budgets_BudgetsId",
                        column: x => x.BudgetsId,
                        principalTable: "Budgets",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BudgetExpense_ExpenseSubsorts_ExpenseSubsortsId",
                        column: x => x.ExpenseSubsortsId,
                        principalTable: "ExpenseSubsorts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AccountExpense",
                columns: table => new
                {
                    AccountsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExpensesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountExpense", x => new { x.AccountsId, x.ExpensesId });
                    table.ForeignKey(
                        name: "FK_AccountExpense_Accounts_AccountsId",
                        column: x => x.AccountsId,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AccountExpense_Expenses_ExpensesId",
                        column: x => x.ExpensesId,
                        principalTable: "Expenses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AccountIncome",
                columns: table => new
                {
                    AccountsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IncomesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountIncome", x => new { x.AccountsId, x.IncomesId });
                    table.ForeignKey(
                        name: "FK_AccountIncome_Accounts_AccountsId",
                        column: x => x.AccountsId,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AccountIncome_Incomes_IncomesId",
                        column: x => x.IncomesId,
                        principalTable: "Incomes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ExpenseExpenseSort",
                columns: table => new
                {
                    ExpenseSortsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExpensesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseExpenseSort", x => new { x.ExpenseSortsId, x.ExpensesId });
                    table.ForeignKey(
                        name: "FK_ExpenseExpenseSort_ExpenseSorts_ExpenseSortsId",
                        column: x => x.ExpenseSortsId,
                        principalTable: "ExpenseSorts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ExpenseExpenseSort_Expenses_ExpensesId",
                        column: x => x.ExpensesId,
                        principalTable: "Expenses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "IncomeIncomeSource",
                columns: table => new
                {
                    IncomeSourcesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IncomesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncomeIncomeSource", x => new { x.IncomeSourcesId, x.IncomesId });
                    table.ForeignKey(
                        name: "FK_IncomeIncomeSource_IncomeSources_IncomeSourcesId",
                        column: x => x.IncomeSourcesId,
                        principalTable: "IncomeSources",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_IncomeIncomeSource_Incomes_IncomesId",
                        column: x => x.IncomesId,
                        principalTable: "Incomes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserAccount",
                columns: table => new
                {
                    AccountsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccount", x => new { x.AccountsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_UserAccount_Accounts_AccountsId",
                        column: x => x.AccountsId,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserAccount_User_UsersId",
                        column: x => x.UsersId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserExpense",
                columns: table => new
                {
                    ExpensesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserExpense", x => new { x.ExpensesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_UserExpense_Expenses_ExpensesId",
                        column: x => x.ExpensesId,
                        principalTable: "Expenses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserExpense_User_UsersId",
                        column: x => x.UsersId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserIncome",
                columns: table => new
                {
                    IncomesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserIncome", x => new { x.IncomesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_UserIncome_Incomes_IncomesId",
                        column: x => x.IncomesId,
                        principalTable: "Incomes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserIncome_User_UsersId",
                        column: x => x.UsersId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DebtUser",
                columns: table => new
                {
                    DebtsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DebtUser", x => new { x.DebtsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_DebtUser_Debts_DebtsId",
                        column: x => x.DebtsId,
                        principalTable: "Debts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DebtUser_User_UsersId",
                        column: x => x.UsersId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Transfers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DebtId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(9,2)", precision: 9, scale: 2, nullable: false),
                    CurrencyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transfers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transfers_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transfers_Debts_DebtId",
                        column: x => x.DebtId,
                        principalTable: "Debts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AccountTransfer",
                columns: table => new
                {
                    AccountsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TransfersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountTransfer", x => new { x.AccountsId, x.TransfersId });
                    table.ForeignKey(
                        name: "FK_AccountTransfer_Accounts_AccountsId",
                        column: x => x.AccountsId,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AccountTransfer_Transfers_TransfersId",
                        column: x => x.TransfersId,
                        principalTable: "Transfers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountExpense_ExpensesId",
                table: "AccountExpense",
                column: "ExpensesId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountIncome_IncomesId",
                table: "AccountIncome",
                column: "IncomesId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_CurrencyId",
                table: "Accounts",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountTransfer_TransfersId",
                table: "AccountTransfer",
                column: "TransfersId");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetExpense_ExpenseSubsortsId",
                table: "BudgetExpense",
                column: "ExpenseSubsortsId");

            migrationBuilder.CreateIndex(
                name: "IX_Budgets_BudgetDurationId",
                table: "Budgets",
                column: "BudgetDurationId");

            migrationBuilder.CreateIndex(
                name: "IX_Budgets_BudgetTypeId",
                table: "Budgets",
                column: "BudgetTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Budgets_CurrencyId",
                table: "Budgets",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Debts_AccountId",
                table: "Debts",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Debts_CurrencyId",
                table: "Debts",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_DebtUser_UsersId",
                table: "DebtUser",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseExpenseSort_ExpensesId",
                table: "ExpenseExpenseSort",
                column: "ExpensesId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_CurrencyId",
                table: "Expenses",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseSorts_ExpenseSubsortId",
                table: "ExpenseSorts",
                column: "ExpenseSubsortId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IncomeIncomeSource_IncomesId",
                table: "IncomeIncomeSource",
                column: "IncomesId");

            migrationBuilder.CreateIndex(
                name: "IX_Incomes_CurrencyId",
                table: "Incomes",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_IncomeSources_IncomeSubsourceId",
                table: "IncomeSources",
                column: "IncomeSubsourceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transfers_CurrencyId",
                table: "Transfers",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Transfers_DebtId",
                table: "Transfers",
                column: "DebtId");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserTypeId",
                table: "User",
                column: "UserTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccount_UsersId",
                table: "UserAccount",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_UserExpense_UsersId",
                table: "UserExpense",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_UserIncome_UsersId",
                table: "UserIncome",
                column: "UsersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountExpense");

            migrationBuilder.DropTable(
                name: "AccountIncome");

            migrationBuilder.DropTable(
                name: "AccountTransfer");

            migrationBuilder.DropTable(
                name: "BudgetExpense");

            migrationBuilder.DropTable(
                name: "DebtUser");

            migrationBuilder.DropTable(
                name: "ExpenseExpenseSort");

            migrationBuilder.DropTable(
                name: "IncomeIncomeSource");

            migrationBuilder.DropTable(
                name: "UserAccount");

            migrationBuilder.DropTable(
                name: "UserExpense");

            migrationBuilder.DropTable(
                name: "UserIncome");

            migrationBuilder.DropTable(
                name: "Transfers");

            migrationBuilder.DropTable(
                name: "Budgets");

            migrationBuilder.DropTable(
                name: "ExpenseSorts");

            migrationBuilder.DropTable(
                name: "IncomeSources");

            migrationBuilder.DropTable(
                name: "Expenses");

            migrationBuilder.DropTable(
                name: "Incomes");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Debts");

            migrationBuilder.DropTable(
                name: "BudgetDurations");

            migrationBuilder.DropTable(
                name: "BudgetTypes");

            migrationBuilder.DropTable(
                name: "ExpenseSubsorts");

            migrationBuilder.DropTable(
                name: "IncomeSubsource");

            migrationBuilder.DropTable(
                name: "UserTypes");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Currency");
        }
    }
}
