﻿namespace Domain.Configurations;

public class ServiceTypeConfiguration 
    : IEntityTypeConfiguration<ServiceTypeEntity>
{
    public void Configure(EntityTypeBuilder<ServiceTypeEntity> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .HasIndex(x => x.Name)
            .IsUnique();
        builder
            .HasIndex(x => x.Description)
            .IsUnique();

        builder
            .HasMany(x => x.Requests)
            .WithOne(x => x.ServiceType);

        builder.HasData(new List<ServiceTypeEntity>
        {
            new()
            {
                Id = 1,
                Name = "Диагностика автомобиля",
                Description = "Комплекс специальных мероприятий по определению точного технического состояния авто и выявления неполадок. " +
                              "Услуга позволяет дать общую оценку работе всех ключевых узлов авто, безошибочно определить неисправности, " +
                              "причину их появления и оптимальный способ устранения.",
                Price = 500
            },
            new()
            {
                Id = 2,
                Name = "Шиномонтажные работы",
                Description = "Если вы столкнулись с необходимостью провести балансировку колес после их замены, " +
                              "то мастера автосервисного предприятия с легкостью выполнят такую работу. Однако " +
                              "владелец автомобиля должен знать, что только полный комплекс работ по шиномонтажу " +
                              "гарантирует максимальную безопасность эксплуатации транспортного средства любой марки и " +
                              "модельного ряда.",
                Price = 2000
            },
            new()
            {
                Id = 3,
                Name = "Электротехнические работы",
                Description = "Электротехнические работы состоят в проверке и ремонте приборов электрооборудования автомобилей. " +
                              "Приборы и агрегаты электрооборудования, неисправности которых не могли быть устранены на постах " +
                              "технического обслуживания, очищают от пыли и грязи, осматривают и испытывают на специальных установках.",
                Price = 3300,
            },
            new()
            {
                Id = 4,
                Name = "Сварочные работы",
                Description = "Для выполнения сварочных работ используется разнообразное оборудование – от простых и компактных бытовых " +
                              "трансформаторов тока до мощных промышленных автоматизированных линий.",
                Price = 2000
            },
            new()
            {
                Id = 5,
                Name = "Ремонт рулевого управления",
                Description = "Техническое обслуживание механизмов рулевого управления носит плановый характер. Объем выполняемых работ " +
                              "определяется видом технического обслуживания. В процессе ежедневного технического обслуживания необходимо проверять " +
                              "свободный ход рулевого колеса, состояние креплений сошки, а также ограничителей максимальных углов поворота управляемых колес. " +
                              "Кроме этого необходимо ежедневно проверять зазор в шарнирах гидроусилителя и в рулевых тягах, а также работу гидроусилителя и " +
                              "рулевого управления. Эти проверки выполняют при работающем двигателе.",
                Price = 4300
            },
            new()
            {
                Id = 6,
                Name = "Замена масла в соответствующих узлах авто",
                Description = "Несвоевременная замена масла в автомобиле провоцирует снижение эксплуатационных и функциональных характеристик соответствующих узлов и " +
                              "систем. Подобные ситуации приводят к быстрому износу и поломкам тех либо иных деталей. Именно поэтому специалисты нашего сервиса рекомендуют " +
                              "менять моторное масло в сроки, установленные специфическими стандартами и нормативами.",
                Price = 2300
            },
            new()
            {
                Id = 7,
                Name = "Осуществление ремонта двигателя",
                Description = "Ремонтные работы по ДВС различаются масштабом и сложностью выполняемых операций, " +
                              "используемыми методами диагностики автомобиля, технологиями замены и восстановления " +
                              "функциональных деталей.",
                Price = 8000
            },
            new()
            {
                Id = 8,
                Name = "Покрасочные работы",
                Description = "Независимо от вида покраски, полная или частичная, требуется точно соблюдать всю технологию процедуры. Необходимо также учесть тот факт, " +
                              "что без применения профессионального оборудования и опыта хорошего результата ждать не стоит.",
                Price = 3700
            }
        });
    }
}